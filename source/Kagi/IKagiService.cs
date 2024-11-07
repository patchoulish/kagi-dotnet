using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public interface IKagiService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<KagiSummarizeResult> SummarizeAsync(
			KagiSummarizeOptions options,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<KagiAnswerResult> AnswerAsync(
			KagiAnswerOptions options,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="limit"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<KagiSearchResult> SearchAsync(
			string query,
			int limit,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<KagiSearchResult> SearchWebEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<KagiSearchResult> SearchNewsEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default);
	}
}
