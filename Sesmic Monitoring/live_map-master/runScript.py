import subprocess, time, threading, os


def pull():
    print("Checking for changes...")
    subprocess.check_output(["git", "checkout","master"])
    op2=subprocess.check_output(["git","pull"])
    if "Already up-to-date." not in op2:
        print("killing and restarting")
        subprocess.call(["sh","killServers.sh"])
        subprocess.call(["sh","startServers.sh"])
    try:
        if os.path.exists("./stop"):
            print("Kill pill present...stopping")
        else:
            print("Will recheck again after 15 min...")
            threading.Timer(60*15, pull).start()
    except x:
        print x

pull()


