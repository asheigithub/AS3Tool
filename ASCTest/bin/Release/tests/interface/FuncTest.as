package {
	[Doc]
	public class FuncTest{
		public function FuncTest() ;
	}
}
/*
����Ψһ��ʵ�ֽӿڵ� ActionScript 3.0 ����Ԫ�ء�����������ʹ�� implements �ؼ��ֿ�ʵ��һ�������ӿڡ�
�����ʾ�����������ӿ� IAlpha �� IBeta �Լ�ʵ���������ӿڵ��� Alpha��
*/
interface IAlpha 
{ 
    function foo(str:String):String; 
} 
 
interface IBeta 
{ 
    function bar():void; 
} 
 
class Alpha implements IAlpha, IBeta 
{ 
    public function foo(param:String):String {  trace("foo", param); return null; } 
    public function bar():void { trace("bar");} 
}

var a=new Alpha();

var alpha:IAlpha = a;
var beta:IBeta = IBeta(alpha);

alpha.foo("call foo");
beta.bar();


