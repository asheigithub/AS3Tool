package {
	[Doc]
	public class FuncTest
	{
	}
}
//�������� Team �ࡣTeam ����������ڸ����ڼ������������Ե� getter �� setter ������ 
class Team { 
		var teamName:String; 
		var teamCode:String; 
		var teamPlayers:Array = new Array(); 
		public function Team(param_name:String, param_code:String) { 
			teamName = param_name; 
			teamCode = param_code; 
		} 
		public function get name():String { 
			return teamName; 
		} 
		public function set name(param_name:String):void { 
			teamName = param_name; 
		}
	} 
	//�ڽű�����������Ĵ��룺 
	
var giants:Team = new Team("San Fran", "SFO"); 
trace(giants.name); 
giants.name = "San Francisco"; 
trace(giants.name); 
/*
San Fran San Francisco */
