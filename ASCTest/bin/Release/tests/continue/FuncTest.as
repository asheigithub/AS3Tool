package {
	[Doc]
	public class FuncTest{
		public function FuncTest()
		{
		//������� while ѭ���У�continue ����������� 3 ��������ʱ����ѭ��������ಿ�֣�����ת��ѭ���Ķ��ˣ��ڸô������������ԣ��� 
			var i:int = 0; 
			while (i < 10) { 
				if (i % 3 == 0) { 
					i++; 
					continue; 
				} 
				trace(i); 
				i++; 
			}
		}
	};
}