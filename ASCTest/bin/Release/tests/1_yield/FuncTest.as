package {
	[Doc]
	public class FuncTest{
		public function FuncTest() {
			/*
			yield �Ǵ�.net2.0�﷨����ֲ���������Զ�����һ����ö�ٶ�����﷨��ÿ��yield return�����Է���һ��ֵ
			yield break��ֹͣö�١�
			*/
			var yieldtest=function(a):*
			{
				for (var i:int = 0; i < 100; i++ )
				{
					if(i>=a)
					{
						trace("exit yield");
						//**������ö�ջ��
						trace(new Error().getStackTrace());
						yield break;
					}
					trace("current output:",i);
					yield return i;
				}
			}
			
			for (var k in yieldtest(4))
			{
				
				
				trace("receive:",k);
				//**������ö�ջ��
				trace(new Error().getStackTrace());
			}
		}
	}
}
