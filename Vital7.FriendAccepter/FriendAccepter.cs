using System;
using System.Composition;
using System.Threading.Tasks;
using ArchiSteamFarm;
using ArchiSteamFarm.Plugins;

namespace Vital7.FriendAccepter {
	[Export(typeof(IPlugin))]
	public class FriendAccepter : IBotFriendRequest {
		public void OnLoaded() {
			ASF.ArchiLogger.LogGenericInfo(Name + " is initialized successfully!");
		}

		public string Name => nameof(FriendAccepter);
		public Version Version => new Version(1, 0, 0, 0);
		public Task<bool> OnBotFriendRequest(Bot bot, ulong steamID) => Task.FromResult(true);
	}
}
