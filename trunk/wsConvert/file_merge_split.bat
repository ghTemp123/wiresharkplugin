@echo 0.����Ŀ¼

cd K:\Ѱ����Ŀ����ï��\SZ_1201_08A

@echo 1.��̨�����ϵ�pcap�ļ�����ʱ��ϲ�......

mergecap -v -T ether -w  mc.cap CE*.cap

@echo 2.�ָ�ɴ�С��ͬ���ļ�......

editcap mc.cap -c 2000000 mc_mergefile.cap

@echo continue......

pause