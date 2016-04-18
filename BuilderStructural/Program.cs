using System;
using System.Collections.Generic;
/*Definition
 * Separate the construction of a complex object from its
 * representation so that the same construction process can
 * create different representations. 
*/
namespace BuilderStructural {
	/// <summary>
	/// MainApp startup class for Structural Builder Design Pattern
	/// </summary>
	public class MainApp {
		public static void Main() {
			//Create Director and builders
			Director dir = new Director();
			Builder b1 = new ConcreteBuilder1();
			Builder b2 = new ConcreteBuilder2();

			//Construct two products
			dir.Construct(b1);
			Product p1 = b1.getResult();
			p1.Show();
			dir.Construct(b2);
			Product p2 = b2.getResult();
			p2.Show();

			//Wait for user
			Console.ReadKey();
		}
	}
	/// <summary>
	/// The "Director" class
	/// </summary>
	class Director {
		public void Construct(Builder builder){
			builder.BuildPartA();
			builder.BuildPartB();
		}
	}

	/// <summary>
	/// The "Builder" abstract class
	/// </summary>
	abstract class Builder {
		public abstract void BuildPartA();
		public abstract void BuildPartB();
		public abstract Product getResult();
	}

	/// <summary>
	/// The "ConcreteBuilder1" class
	/// </summary>
	/// <seealso cref="BuilderStructural.Builder" />
	class ConcreteBuilder1 : Builder {
		private Product _product = new Product();
		public override void BuildPartA() {
			_product.Add("PartA");
		}

		public override void BuildPartB() {
			_product.Add("PartB");
		}

		public override Product getResult() {
			return _product;
		}
	}

	/// <summary>
	/// The "ConcreteBuilder2" class
	/// </summary>
	/// <seealso cref="BuilderStructural.Builder" />
	class ConcreteBuilder2 : Builder {
		private Product _product = new Product();
		public override void BuildPartA() {
			_product.Add("PartX");
		}

		public override void BuildPartB() {
			_product.Add("PartY");
		}

		public override Product getResult() {
			return _product;
		}
	}

	class Product {
		private List<string> _parts = new List<string>();
		public void Add(string part) {
			_parts.Add(part);
		}
		public void Show() {
			Console.WriteLine("\nProduct Parts -------");
			foreach (string part in _parts) Console.WriteLine(part);
		}
	}
}