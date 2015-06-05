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
		public void Compsose_Test1 ()
		{
			var Z1 = FF.Compose (GG);
			var a1 = Z1 (3.14);
			Assert.AreEqual ("3", a1);
		}

		[Test]
		public void Compsose_Test2 ()
		{

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

		public static Func<T, M<V>> Compose<T, U, V>(this Func<U, M<V>> f, Func<T, M<U>> g)
		{
			return x => Bind(g(x), f);
		}

		public static T Identity<T>(this T value)
		{
			return value;
		}
	}
}

