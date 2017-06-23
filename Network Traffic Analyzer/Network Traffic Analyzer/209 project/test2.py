import dpkt
import socket
import pygeoip
import optparse
from requests import get
gi = pygeoip.GeoIP('/home/sanketdhami/Desktop/GeoLiteCity.dat')
l = []
def retKML(ip,host):
	if ip in l:
		return
	else:
		l.append(ip)
		rec = gi.record_by_name(ip)
		ip = ip + ' ' + host		
		try:
			longitude = rec['longitude']
			latitude = rec['latitude']
			kml = ('<Placemark>\n''<name>%s</name>\n''<Point>\n''<coordinates>%6f,%6f</coordinates>\n''</Point>\n''</Placemark>\n')%(ip,longitude, latitude)
			return kml
		except:
			return ''
	
def plotIPs(pcap):
	kmlPts = ''
	for (ts, buf) in pcap:
		try:
			eth = dpkt.ethernet.Ethernet(buf)
			ip = eth.data
			tcp = ip.data
			http = dpkt.http.Request(tcp.data)
			dst = socket.inet_ntoa(ip.dst)
			if http.method == 'GET':
				host_site = http.headers['host']
				dstKML = retKML(dst,host_site)
				kmlPts = kmlPts + dstKML
		except:
			pass
	return kmlPts

def main():
	parser = optparse.OptionParser(usage = 'usage: %test2.py -p test1.pcap')
	parser.add_option('-p', dest='pcapFile', type='string',help='test1.pcap')
	(options, args) = parser.parse_args()
	if options.pcapFile == None:
		print parser.usage
		exit(0)
	pcapFile = options.pcapFile
	f = open(pcapFile)
	pcap = dpkt.pcap.Reader(f)
	kmlheader = '<?xml version="1.0" encoding="UTF-8"?>\n<kml xmlns="http://www.opengis.net/kml/2.2">\n<Document>\n'
	kmlfooter = '</Document>\n</kml>\n'
	kmldoc=kmlheader+plotIPs(pcap)+kmlfooter
	print kmldoc
if __name__ == '__main__':
	main()
