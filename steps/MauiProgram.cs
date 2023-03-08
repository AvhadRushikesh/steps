﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using steps.Repositories;

namespace steps;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MovieRepository>();

		builder.Services.AddSingleton<BGColorRepo>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}