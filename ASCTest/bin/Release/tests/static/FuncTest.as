package {
	[Doc]
	public class FuncTest{
		public function FuncTest() {}
	}
}
/*�����ʾ��˵�����ʹ�� static �ؼ��ִ���һ����������
�ü����������Ѵ������ʵ����������
���� numInstances �����Ǿ�̬�ģ�
�����ֻ�������ഴ��һ�Σ������Ƕ�ÿ������ʵ��������һ�Ρ�*/
class Users { 
	private static var numInstances:Number = 0; 
	function Users() { 
		numInstances++; 
	} 
	static function get instances():Number { 
		return numInstances; 
	} 
}
//�ڽű�����������Ĵ��룺 
trace(Users.instances); 
var user1:Users = new Users(); 
trace(Users.instances); 
var user2:Users = new Users(); 
trace(Users.instances); 
//������չ�� Users �࣬��˵������δ�̳о�̬�����ͷ��������ǿ������������������ǡ� 
class PowerUsers extends Users{
    function PowerUsers() {
        
    }
}
var pu=new PowerUsers();
//trace(PowerUsers.instances); // error, cannot access static property using PowerUsers class
trace(Users.instances); 






