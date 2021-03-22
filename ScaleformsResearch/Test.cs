using Rage;
using Rage.Attributes;
using Rage.ConsoleCommands;
using Rage.ConsoleCommands.AutoCompleters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal static class Test
    {
        private static Dictionary<Movie, GameFiber> tests = new Dictionary<Movie, GameFiber> { };
        internal static void Start(Movie x)
        {
            Stop(x);
            GameFiber f = GameFiber.StartNew(delegate
            {
                x.LoadAndWait();
                x.TestStart();
                while (true)
                {
                    GameFiber.Yield();
                    x.Draw();
                    x.TestTick();
                    if (Game.IsKeyDown(System.Windows.Forms.Keys.End)) break;
                }
                x.TestEnd();
                x.Release();
                tests.Remove(x);
            }, "Scaleform Test");
            tests[x] = f;
        }
        internal static void Stop(Movie x)
        {
            if (tests[x] != null && tests[x].IsAlive)
            {
                tests[x].Abort();
                x.TestEnd();
                x.Release();
            }
            tests.Remove(x);
        }
        internal static void Stop()
        {
            foreach (var x in tests)
            {
                if (x.Value != null && x.Value.IsAlive)
                {
                    x.Value.Abort();
                    x.Key.TestEnd();
                    x.Key.Release();
                }
            }
            tests.Clear();
        }

        [ConsoleCommand("Run Scalform Test")]
        private static void ScaleformTest([ConsoleCommandParameter(AutoCompleterType = typeof(MoviesAutoCompleter))] string type)
        {
            Game.Console.Print("Close Console");
            while (Game.IsPaused) GameFiber.Yield();
            Start((Movie)Activator.CreateInstance(MovieTypes[type]));
        }

        [ConsoleCommand("Stop All Scalform Tests")]
        private static void ScaleformTestStopAll()
        {
            Stop();
        }

        private static Dictionary<string, Type> MovieTypes = new Dictionary<string, Type> { };
        internal class MoviesAutoCompleter : ConsoleCommandParameterAutoCompleter
        {
            public MoviesAutoCompleter(Type type) : base(type)
            {
            }

            public override void UpdateOptions()
            {
                if (Options.Count > 0) return;
                var list = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Movie))).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    MovieTypes[list[i].Name] = list[i];
                    Options.Add(new AutoCompleteOption(list[i].Name, list[i].Name, ""));
                }
            }
        }
    }
}
