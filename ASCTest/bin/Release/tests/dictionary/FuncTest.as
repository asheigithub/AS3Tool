package {
	import flash.utils.Dictionary;
	[Doc]
	public class FuncTest{
		public function FuncTest()
		{
		/*Dictionary �����ڴ������ԵĶ�̬���ϣ��ü���ʹ�� strict equality (===) ��������м��Ƚϡ�������������ʱ��
		��ʹ�ö���ı�ʶ�����Ҷ��󣬶�����ʹ���ڶ����ϵ��� toString() �����ص�ֵ�� */
		
			var dict = new Dictionary();
			 var obj = new Object();
			 var key:Object = new Object();
			 key.toString = function() { return "key" }
			 
			 dict[key] = "Letters";
			 obj["key"] = "Letters";
			 
			trace( dict[key] == "Letters"); // true
			trace( obj["key"] == "Letters"); // true
			trace( obj[key] == "Letters"); // true because key == "key" is true b/c key.toString == "key"
			trace( dict["key"] == "Letters"); // false because "key" === key is false
			
			trace(dict[key]);
			
			delete dict[key]; //removes the key
				
			trace(dict[key]);
			
			dict[1] = "4";
			
			trace(dict["1"]);
		}
	}
}
