@echo off
echo *******************************************************************************
@echo 2010.10.19 �ƶ�qq���ݰ�Gi�ɼ�
echo *******************************************************************************
if exist e:\Progra~1\Wireshark\tshark.exe goto e
if exist f:\Progra~1\Wireshark\tshark.exe goto f
if exist c:\Progra~1\Wireshark\tshark.exe goto c
if exist d:\Progra~1\Wireshark\tshark.exe goto d
:c
c:
cd c:\Program Files\Wireshark 
goto tshark
:d
d:
cd d:\Program Files\Wireshark 
goto tshark
:e
e:
cd e:\Program Files\Wireshark 
goto tshark
:f
f:
cd f:\Program Files\Wireshark 
goto tshark
:tshark
tshark -D
echo *******************************************************************************
echo ָ���ɼ��˿�3,�۲�˿��Ƿ�ָ����ȷ�������޸Ľű�ָ����ȷ�Ĳɼ��˿�
echo ָ��ÿ���ļ���С1.024G
echo �ɼ��ļ�Ŀ¼f��
echo ���ˣ�TCP�˿�14000��UDP�˿�8040��
echo ���ˣ�TM 8000��4000
echo ���ˣ�oicqЭ����˷�����ʱ����ʹ��
echo *******************************************************************************
tshark -i 3 -w f:\t.pcap -b filesize:1024000 -f "tcp port 14000 or udp port 8040 or udp port 8000 or udp port 4000" 
pause




����