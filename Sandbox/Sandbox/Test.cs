using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Sandbox
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void Compsose_Test ()
		{
			var Z1 = FF.Compose (GG);
			var a1 = Z1 (3.14);
			Assert.AreEqual ("3", a1);
		}

		readonly Func<int, string> FF = i => i.ToString().ToUpper(); 
		readonly Func<double, int> GG = d => (int) Math.Floor(d);
	}

	public static class FunctionalExtensions
	{
		public static Func<T, V> Compose<T, U, V>(this Func<U, V> f, Func<T, U> g)
		{
			return x => f(g(x));
		}
	}
}

