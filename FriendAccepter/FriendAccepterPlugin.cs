using System;
using System.Composition;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ArchiSteamFarm.Core;
using ArchiSteamFarm.Plugins.Interfaces;
using ArchiSteamFarm.Steam;
using JetBrains.Annotations;

namespace FriendAccepter {
	[Export(typeof(IPlugin))]
	[UsedImplicitly]
	public class FriendAccepterPlugin : IBotFriendRequest {
		public Task OnLoaded()
		{
			ASF.ArchiLogger.LogGenericInfo($"{Name} by ezhevita | Support & source code: https://github.com/ezhevita/{Name}");

			return Task.CompletedTask;
		}

		public string Name => nameof(FriendAccepter);
		public Version Version => Assembly.GetExecutingAssembly().GetName().Version ?? throw new InvalidOperationException(nameof(Version));

		[CLSCompliant(false)]
		public Task<bool> OnBotFriendRequest(Bot bot, ulong steamID) => Task.FromResult(true);
	}
}
