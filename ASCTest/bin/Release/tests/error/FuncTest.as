package {
	[Doc]
	public class FuncTest{
		public function FuncTest() {}
	}
}
/*
Error ������йؽű��г��ֵĴ������Ϣ��
����ʹ�� Error ���캯�������� Error ����
ͨ������ try ������ڲ�����һ���� Error ���󣬸ö������ catch ����鲶�� 

����ʾ��ʹ�� ErrorExample ��˵����������Զ���������������²�����ɵģ� 
����һ�� Array ���͵ľֲ����� nullArray��������ע�⣬��δ�����µ� Array ����
���캯�������ڴ�����������ʹ�� push() ������ֵ���ص�δ��ʼ���������У��ô����ʹ�� CustomError �ಶ���Զ�����󣬸�����չ Error��
���� CustomError ʱ�����캯�����䲶�����һ��������Ϣ��ʹ�� trace() ��䣩�� 

*/
class CustomError extends Error 
{
    public function CustomError(message:String) 
    {
        super(message);
    }
}
var nullArray:Array;
try 
{
	nullArray.push("item");
}
catch(e:Error) 
{
	trace("catch error.");
	trace(e.getStackTrace());
	trace("throw CustomError");
	
	try
	{
		throw new CustomError("nullArray is null");
	}
	catch(e:CustomError)
	{
		trace("catch CustomError and re throw");
		throw e;
	}
	finally
	{
		trace("finally CustomError");
	}
}
finally
{
	trace("finally");
}

