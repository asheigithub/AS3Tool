package {
	[Doc]
	public class FuncTest{
		public function FuncTest() {
		}
	}
}
/*
��̳� -- ����Ҫ�ļ̳л��ƣ���֧�̶ֹ����Եļ̳С��̶�����������Ϊ�ඨ��һ���ֵı����������򷽷������ڣ���ͨ���洢�������Ϣ������������ʾÿ���ඨ�塣 

ԭ�ͼ̳� -- ÿ���඼��һ��������ԭ�Ͷ��󣬶�ԭ�Ͷ���������ɸ��������ʵ������
�ڴ���һ����ʵ��ʱ�������ж������ԭ�Ͷ�������ã��⽫��Ϊʵ���������������ԭ�Ͷ��������ӡ�
����ʱ���������ʵ�����Ҳ���ĳ���ԣ�
�����ί�У������ԭ�Ͷ������Ƿ��и����ԡ�
���ԭ�Ͷ��󲻰����������ԣ�
�˹��̻�����ڲ�νṹ�������ĸ��߼����϶�ԭ�Ͷ������ί�м�飬ֱ���ҵ�������Ϊֹ��
*/
//��̳к�ԭ�ͼ̳п�ͬʱ���ڣ���������ʾ��
class A {
     var x = 1
	 public function A()
	 {
     A.prototype.px = 2
	 }
 }
 dynamic class B extends A {
     var y = 3
	 public function B()
	 {
     B.prototype.py = 4
	 }
 }
  
 var b = new B()
 trace(b.x) // 1 via class inheritance
  trace(b.px) // 2 via prototype inheritance from A.prototype
  trace(b.y) // 3
  trace(b.py) // 4 via prototype inheritance from B.prototype
  
 B.prototype.px = 5
  trace(b.px) // now 5 because B.prototype hides A.prototype
  
 b.px = 6
  trace(b.px) // now 6 because b hides B.prototype
  
  var b2=new B()
  trace(b2.px) // ==5
  
  
  

  
  