using System;
using System.Threading;
using Microsoft.AspNetCore.SignalR.Client;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissorsBoom.Server.Bot
{
    public class SignalRBot : BaseBot
    {
        private readonly HubConnection _connection;
        private Decision? _decision = null;
        public SignalRBot(string name, string apiRootUrl)
        {
            Name = name;
            _connection = new HubConnectionBuilder()
                .WithUrl(apiRootUrl)
                .Build();
            _connection.StartAsync().Wait();

            _connection.On<Decision>("MakeDecision", (decision) =>
            {
                _decision = decision;
            });
        }

        public override Decision GetDecision(PreviousDecisionResult previousResult)
        {

            _connection.InvokeAsync("RequestMove", previousResult);

            while (_decision == null)
            {
            }

            var decisionToReturn = _decision;
            _decision = null;
            return decisionToReturn.Value;
        }
    }
}