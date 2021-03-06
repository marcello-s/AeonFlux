﻿#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class ObjectLiteralExpression : IExpression
    {
        public IExpression Definitions { get; private set; }

        public ObjectLiteralExpression(IExpression definitions)
        {
            Definitions = definitions;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append("object: ");
            Definitions.AppendTo(sb);
        }
    }
}
