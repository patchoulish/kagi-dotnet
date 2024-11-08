using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kagi
{
	/// <summary>
	/// Provides an interface for objects acting as service clients for the Kagi API.
	/// </summary>
	public interface IKagiService
	{
		/// <summary>
		/// Summarizes the content specified by either
		/// <see cref="KagiSummarizeOptions.Url"/> or
		/// <see cref="KagiSummarizeOptions.Text"/> using
		/// the specified options and returns the result of the operation.
		/// </summary>
		/// <param name="options">The specified options.</param>
		/// <param name="cancellationToken">The cancellation token for the operation.</param>
		/// <returns></returns>
		public Task<KagiSummarizeResult> SummarizeAsync(
			KagiSummarizeOptions options,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Answers the query specified by
		/// <see cref="KagiAnswerOptions.Query"/> using
		/// the specified options and returns the result of the operation.
		/// </summary>
		/// <param name="options">The specified options.</param>
		/// <param name="cancellationToken">The cancellation token for the operation.</param>
		/// <returns></returns>
		public Task<KagiAnswerResult> AnswerAsync(
			KagiAnswerOptions options,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Performs a search and returns the results.
		/// </summary>
		/// <param name="query">The query to search for.</param>
		/// <param name="limit">The maximum number of results to return.</param>
		/// <param name="cancellationToken">The cancellation token for the operation.</param>
		/// <returns></returns>
		public Task<KagiSearchResult> SearchAsync(
			string query,
			int limit,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Fetches and returns enrichment results focused on non-commercial news and discussions.
		/// </summary>
		/// <param name="query">The query to fetch enrichment results for.</param>
		/// <param name="cancellationToken">The cancellation token for the operation.</param>
		/// <returns></returns>
		public Task<KagiSearchResult> GetWebEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Fetches and returns enrichment results focused on general, non-commercial web content.
		/// </summary>
		/// <param name="query">The query to fetch enrichment results for.</param>
		/// <param name="cancellationToken">The cancellation token for the operation.</param>
		/// <returns></returns>
		public Task<KagiSearchResult> GetNewsEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default);
	}
}
