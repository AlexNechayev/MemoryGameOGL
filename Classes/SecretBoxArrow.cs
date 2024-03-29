﻿using myOpenGL.Structs;
using OpenGL;

namespace myOpenGL.Classes
{
    public class SecretBoxArrow
    {
        private SecretBoxMatrix m_SecretBoxMatrixInstance;
        private GLUquadric m_GLUquadricObject;
        public bool DrawSecretBoxArrowFlag { get; set; }

        public SecretBoxArrow(SecretBoxMatrix i_SecretBoxMatrix)
        {
            this.DrawSecretBoxArrowFlag = true;
            this.m_GLUquadricObject = GLU.gluNewQuadric();
            this.m_SecretBoxMatrixInstance = i_SecretBoxMatrix;
        }

        ~SecretBoxArrow()
        {
            GLU.gluDeleteQuadric(this.m_GLUquadricObject);
        }

        public void ResetSecretBoxArrow()
        {
            this.DrawSecretBoxArrowFlag = true;
            this.m_SecretBoxMatrixInstance.CountUserTurnCounter();
            this.DrawSelectedSecretBoxArrow();
        }

        public void DrawSelectedSecretBoxArrow(bool i_DrawShadowFlag = false)
        {
            if (DrawSecretBoxArrowFlag)
            {
                this.performSecretBoxArrowDrawing(i_DrawShadowFlag);
            }
        }

        private void performSecretBoxArrowDrawing(bool i_DrawShadowFlag)
        {
            if (this.m_SecretBoxMatrixInstance.DrawSelectedSecretBoxArrowFlag)
            {
                Point3D currentPoint = this.m_SecretBoxMatrixInstance.CurrentSecretBoxPointer.TranslatePoint;
                GL.glPushMatrix();

                if (i_DrawShadowFlag)
                {
                    GL.glColor3f(0.3f, 0.0f, 0.0f);
                }
                else
                {
                    GL.glColor3f(1, 0, 0);
                }

                GL.glTranslatef(currentPoint.X + 0.5f, currentPoint.Y + 3.5f, currentPoint.Z + 0.5f);
                GL.glRotatef(-90, 1, 0, 0);
                GLU.gluCylinder(this.m_GLUquadricObject, 0.0, 0.5, 1.5, 16, 16);
                GL.glTranslatef(-1 * (currentPoint.X + 0.5f), -1 * (currentPoint.Y + 3.5f), -1 * (currentPoint.Z + 0.5f));

                GL.glPopMatrix();
            }
        }
    }
}