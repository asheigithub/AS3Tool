package {
	[Doc]
	public class FuncTest{
		public function FuncTest() {}
	}
}
//this
//�Է����İ�����������á�ִ�нű�ʱ��this �ؼ������ð����ýű��Ķ����ڷ�������ڲ���this �ؼ������ð������÷�������ʵ����
//��Ҫ�����ڶ�̬���ж���ĺ����������ʹ�� this �����ʵ��������ڵĺ�����


// incorrect version of Simple.as
/*
dynamic class Simple {
    function callfunc() {
        func();
    }
}
*/
// correct version of Simple.as
dynamic class Simple {
    function callfunc() {
        this.func();
    }
}
//������Ĵ�����ӵ����Ľű��У� 
var simpleObj:Simple = new Simple();
simpleObj.func = function() {
	trace("hello there");
}
simpleObj.callfunc();
//������ callfunc() ������ʹ�� this ʱ�����ϴ�����Ч�������������ʹ���˲���ȷ�� Simple.as �汾���������﷨�������������ѱ�ע�͵����� 

