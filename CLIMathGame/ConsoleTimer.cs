using System;
using System.Threading;

namespace CLIMathGame
{
    public class ConsoleTimer : IDisposable
    {
        private readonly Timer _timer;
        private readonly int _interval;
        private int _elapsed;
        private ConsoleKeyInfo _lastKeystroke;

        public ConsoleTimer(int interval)
        {
            _interval = interval;
            _timer = new Timer(TimerCallback, null, 0, interval);
        }

        private void TimerCallback(object state)
        {
            _elapsed += _interval;
            Console.SetCursorPosition(0, 0);
            Console.Write($"Elapsed time: {_elapsed / 1000}s \n\n {state} \n\n {_lastKeystroke.KeyChar}");
        }

        public void UpdateLastKeystroke(ConsoleKeyInfo keyInfo)
        {
            _lastKeystroke = keyInfo;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
