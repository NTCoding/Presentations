using System.Linq;

namespace SOLID_is_a_guideline
{
	public interface IDocumentSession
	{
		IQueryable<T> Query<T>();
	}
}