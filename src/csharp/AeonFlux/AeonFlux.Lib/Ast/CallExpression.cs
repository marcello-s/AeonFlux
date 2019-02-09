#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class CallExpression : IExpression
    {
        public IExpression Function { get; private set; }
        public IExpression Args { get; private set; }

        public CallExpression(IExpression function, IExpression args)
        {
            Function = function;
            Args = args;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append("call: ");
            Function.AppendTo(sb);
            sb.Append("(");
            Args.AppendTo(sb);
            sb.Append(")");
        }
    }
}
