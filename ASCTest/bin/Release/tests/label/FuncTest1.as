package {
	[Doc]
	public class FuncTest1{
	/*
	����˵�����ʹ��Ƕ��ѭ���ı�ǩ����������ϵ�е�ѭ����
	����ʹ��Ƕ��ѭ�������ɴ� 0 �� 99 �������б�
	�����ּ����ﵽ 80 ǰ���� break ��䡣
	��� break ���δʹ�� outerLoop ��ǩ������뽫��������һѭ�������ಿ�֣�
	���Ҵ��뽫��������� 90 �� 99 �����֡�
	Ȼ������Ϊʹ���� outerLoop ��ǩ��
	break ��佫��������ϵ��ѭ�������ಿ�֣��������������� 79�� 
	*/
		public function FuncTest1() {
			outerLoop: for (var i:int = 0; i < 10; i++) {
			for (var j:int = 0; j < 10; j++) {
				if ( (i == 8) && (j == 0)) {
					break outerLoop;
				}
				trace(10 * i + j);
			}
		}
		/*
		1
		2
		...
		79
		*/
		}
	}
}