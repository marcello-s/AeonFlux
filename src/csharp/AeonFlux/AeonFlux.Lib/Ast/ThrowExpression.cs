#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2018 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class ThrowExpression : IExpression
    {
        public IExpression Expr { get; private set; }

        public ThrowExpression(IExpression expr)
        {
            Expr = expr;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append("throw: ");
            Expr.AppendTo(sb);
        }
    }
}
