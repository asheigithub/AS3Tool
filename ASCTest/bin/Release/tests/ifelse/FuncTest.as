
package {
	[Doc]
	public class FuncTest{};
}
//����ʾ��ʹ�� if �� else ����������� score_txt ���ض���ֵ���бȽϣ� 
var score_txt={"text":70};

if (score_txt.text>90) { 
	trace("A"); 
} 
else if (score_txt.text>75) { 
	trace("B"); 
} 
else if (score_txt.text>60) { 
	trace("C"); 
} 
else { 
	trace("F"); 
}