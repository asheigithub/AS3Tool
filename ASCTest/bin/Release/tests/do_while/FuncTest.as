package {
	[Doc]
	public class FuncTest{
		public function FuncTest()
		{
		//����ʾ��ʹ�� do..while ѭ�������������Ƿ�Ϊ true�������� myVar��ֱ�� myVar ���ڵ��� 5 Ϊֹ��myVar ���ڵ��� 5 ʱ��ѭ�������� 
			var myVar:Number = 0; 
			do { 
				trace(myVar); 
				myVar++; 
			} 
			while (myVar < 5); 
			/*
			0 
			1 
			2 
			3 
			4
			*/
		}
	};
}
