﻿#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class PrefixExpression : IExpression
    {
        public Parser.Token TokenId { get; private set; }
        public IExpression Right { get; private set; }

        public PrefixExpression(Parser.Token tokenId, IExpression right)
        {
            TokenId = tokenId;
            Right = right;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append("(");
            sb.Append(TokenId);
            sb.Append(" ");
            Right.AppendTo(sb);
            sb.Append(")");
        }
    }
}
