
package {
	[Doc]
	public class FuncTest{};
}
/*
�������ʾ���У�Car ����չ Vehicle �࣬�Լ̳������з��������Ժͺ�����
������Ľű��� Car �������ʵ������������ Car ��ķ��������� Vehicle ��ķ���������ʹ�á� 
�����ʾ����ʾ��Ϊ Vehicle.as ���ļ��������� Vehicle �ࣩ�����ݣ� 

package {
	class Vehicle { 
	    var numDoors:Number; 
	    var color:String; 
	    public function Vehicle(param_numDoors:Number = 2, param_color:String = null) { 
	        numDoors = param_numDoors; 
	        color = param_color; 
	    } 
	    public function start():void { 
	        trace("[Vehicle] start"); 
	    } 
	    public function stop():void { 
	        trace("[Vehicle] stop"); 
	    } 
	    public function reverse():void { 
	        trace("[Vehicle] reverse"); 
	    } 
	}	
}

�����ʾ����ʾͬһĿ¼����Ϊ Car.as �ĵڶ��� ActionScript �ļ���
������չ Vehicle �࣬ͨ�����ַ�ʽ�޸�������һ���� Car ����ӱ��� fullSizeSpare �Ը��� car �����Ƿ���б�׼�ߴ�ı�����̥���ڶ�����������ض����������·��� activateCarAlarm()��
�÷������ڼ��������ķ���������
�������������� stop() ��������� Car ��ʹ�÷������ƶ�ϵͳ��ͣ������ʵ�� 

package {

	public class Car extends Vehicle { 
	    var fullSizeSpare:Boolean; 
	    public function Car(param_numDoors:Number, param_color:String, param_fullSizeSpare:Boolean) { 
	        numDoors = param_numDoors; 
	        color = param_color; 
	        fullSizeSpare = param_fullSizeSpare; 
	    } 
	    public function activateCarAlarm():void { 
	        trace("[Car] activateCarAlarm"); 
	    } 
	    public override function stop():void { 
	        trace("[Car] stop with antilock brakes"); 
	    } 
	}
}

����ʾ���� Car �������ʵ������������ Vehicle ���ж���ķ��� (start())��
Ȼ������� Car �า�ǵķ��� (stop())��
���� Car �����һ������ (activateCarAlarm())�� 
*/

var myNewCar:Car = new Car(2, "Red", true); 
myNewCar.start(); // [Vehicle] start 
myNewCar.stop(); // [Car] stop with anti-lock brakes 
myNewCar.activateCarAlarm(); // [Car] activateCarAlarm

/*
ʹ�� super ���Ҳ���Ա�д Vehicle ������࣬���������ʹ�ø������ʳ���Ĺ��캯����
�����ʾ����ʾ������ ActionScript �ļ������ļ���Ϊ Truck.as��
Ҳ��ͬһĿ¼�С��ڹ��캯���͸��ǵ� reverse() �����У�Truck ��ʹ�� super�� 

package {
	class Truck extends Vehicle {
		var numWheels:Number;
		public function Truck(param_numDoors:Number, param_color:String, param_numWheels:Number) { 
			super(param_numDoors, param_color); 
			numWheels = param_numWheels; 
		} 
		public override function reverse():void { 
			beep();
			super.reverse();
		} 
		public function beep():void { 
			trace("[Truck] make beeping sound"); 
		} 
	}
}
����ʾ���� Truck �������ʵ������������ Truck �า�ǵķ��� (reverse())��
Ȼ������� Vehicle ���ж���ķ��� (stop())�� 

*/

var myTruck:Truck = new Truck(2, "White", 18); 
myTruck.reverse(); // [Truck] make beeping sound [Vehicle] reverse 
myTruck.stop(); // [Vehicle] stop



