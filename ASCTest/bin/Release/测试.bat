@echo �ű�ϵͳ�ĳ�����Ĺ�����ȫ����ɡ����� ��̳У��ӿڣ�ԭ����,�ṹ���쳣���� try catch ,�����ǩlabel��δʵ���Ҳ�׼��ʵ�ֵ�����Ҫ��Ϊ namespace��with��
@echo ������������ yield����C#��yield�﷨��ȫһ�£������Զ�����һ��ö�������󣬲μ�test yield
@echo=
@echo=
 
@echo tests�µ�ÿһ�����ļ��ж���һ��������Ŀ
@echo ����ASCTest	.\tests\XXX	��������һ������
@echo ���������ѭ��ִ��ÿһ�����ԡ�
@echo ��Ŀ�е�as3����ΪANSI.��Ϊ���������������ANSI���뽫�޷���ȷ��ʾ����
@echo ʵ����as3�ļ��ı���Ӧ����UTF-8��

@echo=
@echo ----
@echo=

@set /p var=���������ʼ����


@set n=0

::@cd .\tests

@for /R .\tests  %%i in (.) do  @call:process %%~ni

pause
exit

:process
::@echo %1
::@goto subend

@set /a n+=1
@if %n%==1 (goto subend)

@cls

@echo show src code  %1
@echo=

@if not exist .\tests\%1\FuncTest.as (goto subend)

@type .\tests\%1\FuncTest.as



@set /p var=���������ʼ���벢ִ��
@echo ---build and run---
@ASCTest	.\tests\%1


@set /p var=�������������һ������


:subend
