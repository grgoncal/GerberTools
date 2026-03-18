using System;
using System.Threading.Tasks;

namespace GerberTools.Tools
{
    public static class Actions
    {
        public static Action EmptyAction() => () => { };
        public static Func<Task> EmptyFunc() => async () => { await Task.Yield(); };
    }
}
