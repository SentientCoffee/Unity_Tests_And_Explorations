namespace TestDLL {
	public class DLLClass {

		public int GetRandomInt() {
			var rand = new System.Random();
			return rand.Next();
		}
	}
}
