package {
	[Doc]
	public class FuncTest{
		public function FuncTest() {
			var myExt:Extender = new Extender(); 
		}
	}
}
/*
���ʹ����ͬ������еľ�̬������ͬ�����ƶ���ʵ�����ԣ�
��ʵ�����������������е����ȼ��Ƚϸߡ�
�����Ϊʵ�������ڱ��˾�̬���ԣ�����ζ�Ż�ʹ��ʵ�����Ե�ֵ������ʹ�þ�̬���Ե�ֵ��
���磬���´�����ʾ��� Extender �ඨ����Ϊ test ��ʵ��������
trace() ��佫ʹ��ʵ��������ֵ������ʹ�þ�̬������ֵ��
*/
class Base { 
    public static var test:String = "static"; 
} 
 
class Extender extends Base 
{ 
	public var test:String = "instance";
    public function Extender() 
    { 
        trace(test); // output: static 
    } 
     
}






