package {
	[Doc]
	public class FuncTest{
		public function FuncTest() {
		//����������������ǰ����ֵ�����û������ֵ����� value == null���������һ����Ϣ�� 
			var testArray:Array = new Array();
			testArray[0] = "fee";
			testArray[1] = "fi";
			testArray[4] = "foo";

			for (var i = 0; i < 6; i++) {
				if (testArray[i] == null) {
					trace("testArray[" + i + "] == null");
				}
			}

			/* 
			testArray[2] == null
			testArray[3] == null
			testArray[5] == null
			*/
		}
	}
}