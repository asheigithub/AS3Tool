package {
	[Doc]
	public class FuncTest{
		public function FuncTest() {
			var myExt:Extender = new Extender(); 
		}
	}
}
/*
��Ȼ�����̳о�̬���ԣ����Ǿ�̬�����ڶ������ǵ���������κ���������������С�ͬ����������Ϊ��̬�����ڶ������ǵ�����κ������������ �С�
����ζ���ڶ��徲̬���Ե����弰������κ������п�ֱ�ӷ��ʾ�̬���ԡ� 
��˵�� Base ���ж���� test ��̬������ Extender ����������С�
���仰˵�� Extender ����Է��� test ��̬�������������ö��� test ��������Ϊ������ǰ׺��
*/
class Base { 
    public static var test:String = "static"; 
} 
 
class Extender extends Base 
{ 
    public function Extender() 
    { 
        trace(test); // output: static 
    } 
     
}






