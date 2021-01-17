using System;
using System.Composition;
using System.Reflection;
using System.Threading.Tasks;
using ArchiSteamFarm;
using ArchiSteamFarm.Plugins;
using JetBrains.Annotations;

namespace FriendAccepter {
	[Export(typeof(IPlugin))]
	[UsedImplicitly]
	public class FriendAccepter : IBotFriendRequest {
		public void OnLoaded() {
			ASF.ArchiLogger.LogGenericInfo(Name + " is initialized successfully!");
		}

		public string Name => nameof(FriendAccepter);
		public Version Version => Assembly.GetExecutingAssembly().GetName().Version ?? throw new InvalidOperationException(nameof(Version));
		public Task<bool> OnBotFriendRequest(Bot bot, ulong steamID) => Task.FromResult(true);
	}
}
