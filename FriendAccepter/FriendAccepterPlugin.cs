using System;
using System.Composition;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ArchiSteamFarm.Core;
using ArchiSteamFarm.Plugins.Interfaces;
using ArchiSteamFarm.Steam;
using JetBrains.Annotations;

namespace FriendAccepter;

[Export(typeof(IPlugin))]
[UsedImplicitly]
internal sealed class FriendAccepterPlugin : IBotFriendRequest, IGitHubPluginUpdates {
	public Task OnLoaded()
	{
		ASF.ArchiLogger.LogGenericInfo($"{Name} by ezhevita | Support & source code: https://github.com/{RepositoryName}");

		return Task.CompletedTask;
	}

	public string Name => nameof(FriendAccepter);
	public string RepositoryName => "ezhevita/FriendAccepter";
	public Version Version => Assembly.GetExecutingAssembly().GetName().Version ?? throw new InvalidOperationException(nameof(Version));

	public Task<bool> OnBotFriendRequest(Bot bot, ulong steamID, CancellationToken cancellationToken = default) => Task.FromResult(true);
}