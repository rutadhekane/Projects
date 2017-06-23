import dpkt
import socket
import pygeoip
import datetime
import optparse
from requests import get
gi = pygeoip.GeoIP('/home/sanketdhami/Desktop/GeoLiteCity.dat')
def retGeoStr(ip):
	try:
		rec = gi.record_by_name(ip)
		city = rec['city']
		country = rec['country_code3']
		if city != '':
			geoLoc = city + ', ' + country
		else:
			geoLoc = country
		return geoLoc
	except Exception, e:
		return 'Unregistered'
def printPcap(pcap):
	for (ts, buf) in pcap:
		try:
			eth = dpkt.ethernet.Ethernet(buf)
			ip = eth.data
			src = socket.inet_ntoa(ip.src)
			src1 = src
			tcp = ip.data			
			dst = socket.inet_ntoa(ip.dst)
			dst1 = dst
			http = dpkt.http.Request(tcp.data)
			src_mac = ':'.join('%02x' % ord(b) for b in eth.src)
			if(src_mac == 'f4:06:69:97:33:21'):
				continue
			if http.method == 'GET':
				uri = http.uri.lower()
				print uri
				print 'Timestamp: ', str(datetime.datetime.utcfromtimestamp(ts))
				if('10.0.' in src):
					src = get('https://api.ipify.org').text
					src= str(src)						
			
				if('10.0.' in dst):
					dst = get('https://api.ipify.org').text
					dst= str(dst)
				print '[+] Src: ' + src1 + ' --> Dst: ' + dst1
				print '[+] Src: ' + retGeoStr(src) + ' --> Dst: '  + retGeoStr(dst)
				print '=========================================\n'
		except:
			pass
def main():
	parser = optparse.OptionParser(usage = 'usage: %test1.py -p test1.pcap')
	parser.add_option('-p', dest='pcapFile', type='string',help='test1.pcap')
	(options, args) = parser.parse_args()
	if options.pcapFile == None:
		print parser.usage
		exit(0)
	pcapFile = options.pcapFile
	f = open(pcapFile)
	pcap = dpkt.pcap.Reader(f)
	printPcap(pcap)
if __name__ == '__main__':
	main()
