using System;
namespace OAuthTwitterWrapper
{
	public interface IOAuthTwitterWrapper
	{
		string GetMyTimeline();
		string GetSearch();

        IAuthenticateSettings AuthenticateSettings { get; set; }
        ITimeLineSettings TimeLineSettings { get; set; }
        ISearchSettings SearchSettings { get; set; }
    }
}
