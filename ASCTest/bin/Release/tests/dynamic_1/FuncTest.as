package {
	[Doc]
	public class FuncTest{
		public function FuncTest()
		{
		}
	};
}
//���������������࣬һ��������Ϊ Expando �Ķ�̬�࣬��һ��������Ϊ Sealed ���ܷ��࣬��������ʾ����ʹ�����ǡ� 
dynamic class Expando  {
	}
	
class Sealed {
	}
//���´��봴�� Expando ���ʵ������˵���������ʵ��������ԡ� 
var myExpando:Expando = new Expando();
myExpando.prop1 = "new";
trace(myExpando.prop1); // new

//���´��봴�� Sealed ���ʵ������˵������������Խ����´��� 
var mySealed:* = new Sealed();
mySealed.prop1 = "newer"; // error

