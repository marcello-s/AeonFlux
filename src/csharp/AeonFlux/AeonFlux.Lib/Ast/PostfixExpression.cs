#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2017 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class PostfixExpression : IExpression
    {
        public IExpression Left { get; private set; }
        public Parser.Token TokenId { get; private set; }

        public PostfixExpression(IExpression left, Parser.Token tokenId)
        {
            Left = left;
            TokenId = tokenId;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append("(");
            Left.AppendTo(sb);
            sb.Append(TokenId);
            sb.Append(")");
        }
    }
}
