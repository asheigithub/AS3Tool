
package {
	[Doc]
	public class FuncTest{};
}
//�����ʾ��ʹ�� for �����������Ԫ�أ� 
var my_array:Array = new Array(); 
for (var i:Number = 0; i < 10; i++) { 
	my_array[i] = (i + 5) * 10;  
} 
trace(my_array); // 50,60,70,80,90,100,110,120,130,140 



//�����ʾ��ʹ�� for �ظ�ִ����ͬ�Ķ������ڴ����У�for ѭ������ 1 �� 100 ��������ӡ� 
var sum:Number = 0; 
for (var i:Number = 1; i <= 100; i++) { 
	sum += i; 
} 
trace(sum); // 5050

//����ʾ��˵���������ִ��һ����䣬�򲻱��ô����� ({})�� 
var sum:Number = 0; 
for (var i:Number = 1; i <= 100; i++) 
	sum += i; 
trace(sum); // 5050

