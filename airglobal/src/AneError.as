package
{
	public dynamic class AneError extends Error
	{
		public function AneError (message:String="", id:int=0)
		{
		
			super(message, id);
			name="AneError";
		}
	}
}