@echo on
rem ʹ��WMIC��ȡ������Ϣ�е�QQ·��
for /f "tokens=2 delims==" %%a in ('wmic process where "name='tm.exe'" get executablepath /value') do (
  set QQPath=%%a
)
echo %QQPath%
pause