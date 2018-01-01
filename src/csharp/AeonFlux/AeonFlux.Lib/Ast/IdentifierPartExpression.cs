#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2018 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class IdentifierPartExpression : IExpression
    {
        public IExpression Left { get; private set; }
        public IExpression Exprs { get; private set; }

        public IdentifierPartExpression(IExpression left, IExpression exprs)
        {
            Left = left;
            Exprs = exprs;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            Left.AppendTo(sb);
            sb.Append(".");
            Exprs.AppendTo(sb);
        }
    }
}
