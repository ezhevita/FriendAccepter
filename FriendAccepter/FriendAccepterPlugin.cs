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
		public void OnLoaded() {
			Assembly assembly = Assembly.GetExecutingAssembly();
			string repository = assembly
				.GetCustomAttributes<AssemblyMetadataAttribute>()
				.First(x => x.Key == "RepositoryUrl")
				.Value ?? throw new InvalidOperationException(nameof(AssemblyMetadataAttribute));

			const string git = ".git";
			int index = repository.IndexOf(git, StringComparison.Ordinal);
			if (index >= 0) {
				repository = repository[..(index + 1)];
			}

			string company = assembly
				.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? throw new InvalidOperationException(nameof(AssemblyCompanyAttribute));

			ASF.ArchiLogger.LogGenericInfo(Name + " by " + company + " | Support & source code: " + repository);
		}

		public string Name => nameof(FriendAccepter);
		public Version Version => Assembly.GetExecutingAssembly().GetName().Version ?? throw new InvalidOperationException(nameof(Version));

		[CLSCompliant(false)]
		public Task<bool> OnBotFriendRequest(Bot bot, ulong steamID) => Task.FromResult(true);
	}
}
