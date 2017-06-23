import dpkt
import socket
import datetime
import os
import subprocess, sys
def findDownload(pcap):
	for (ts, buf) in pcap:
		try:
			eth = dpkt.ethernet.Ethernet(buf)
			ip = eth.data	
			src = socket.inet_ntoa(ip.src)
			tcp = ip.data
			src_mac = ':'.join('%02x' % ord(b) for b in eth.src)
			if(src_mac == 'f4:06:69:97:33:21'):
				continue
			http = dpkt.http.Request(tcp.data)
			if http.method == 'GET':
				uri = http.uri.lower()
				if '.zip' in uri and 'loic' in uri:
					print '[!] ' + src + ' Downloaded LOIC.'
					print 'Users MAC address is :' + src_mac
					print 'Timestamp: ', str(datetime.datetime.utcfromtimestamp(ts))
					print 'website:'  + http.headers['host']
					print 'URI is:' + uri
					print '**************************'
					print 
				if '.exe' in uri and 'ccsetup517.exe' in uri:
					print '[!] ' + src + ' Downloaded EXE.'
					print 'Users MAC address is :' + src_mac
					print 'Timestamp: ', str(datetime.datetime.utcfromtimestamp(ts))
					print 'website:'  + http.headers['host']
					print 'URI is:' + uri
					print '**************************'
					print 
			
		except:
			pass

while(1):
	print ('Enter number from the menu:')
	print ('1: Find culprit user')
	print ('2: Find location of destination address')
	print ('3: Find location of destination address on google earth')
	print ('4: Exit')
	x = int(raw_input())
	print 
	if(x == 1):
		f = open('/home/sanketdhami/Desktop/209 project/test1.pcap')
		pcap = dpkt.pcap.Reader(f)
		findDownload(pcap)
		print 
		print '*******************************************************************************************************'


	elif(x == 2):
		os.system('python test1.py -p test1.pcap')
		print 
		print '*******************************************************************************************************'

	elif(x == 3):
		os.system('python test2.py -p test1.pcap > test1.kml')
		print 'KML file generated.\n Open KML file using Google Earth.\n'
	elif(x == 4):
		print 'Exiting from application.....\n'
		exit()
	else:
		print 'Exiting from application.....\n'
		exit()

