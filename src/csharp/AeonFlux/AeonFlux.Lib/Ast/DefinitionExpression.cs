﻿#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class DefinitionExpression : IExpression
    {
        public IExpression IdentifierExpr { get; private set; }
        public IExpression DefinitionExpr { get; private set; }
        public object Tag { get; set; }

        public DefinitionExpression(IExpression identifierExpr, IExpression definitionExpr)
        {
            IdentifierExpr = identifierExpr;
            DefinitionExpr = definitionExpr;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            IdentifierExpr.AppendTo(sb);
            sb.Append("=");
            DefinitionExpr.AppendTo(sb);
        }
    }
}
