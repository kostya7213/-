#include <cstdlib>
#include <windows.h>
#pragma comment(lib, "Glaux.lib") 
#pragma comment(lib, "glu32.lib")
#pragma comment(lib, "OpenGL32.lib")
#include <GL/glut.h>
#include <GL/gl.h>
#include <GL/glu.h>
//#include <glaux.h>
#include <math.h>
#include<gl/glaux.h>


float mat1_dif1[] = { 0.0f,0.0f,1.0f };
float mat1_dif2[] = { 0.0f,0.8f,1.0f };
float mat1_dif3[] = { 0.0f,0.8f,0.0f };
float mat1_dif4[] = { 0.8f,0.8f,0.0f };
float mat1_dif5[] = { 0.9f,0.3f,0.0f };
float mat1_amb[] = { 0.2f,0.2f,0.2f };
float mat1_spec[] = { 0.6f,0.6f,0.6f };
float mat1_shininess = 0.5f * 128;

float mat2_dif[] = { 0.8f,0.0f,1.0f };
float mat2_amb[] = { 0.2f,0.2f,0.2f };
float mat2_spec[] = { 0.6f,0.6f,0.6f };
float mat2_shininess = 0.7f * 128;

float mat3_dif[] = { 1.0f,0.0f,0.0f };
float mat3_amb[] = { 0.2f,0.2f,0.2f };
float mat3_spec[] = { 0.6f,0.6f,0.6f };
float mat3_shininess = 0.1f * 128;

void init(void)
{
    GLfloat light_ambient[] = { 0.0, 0.0, 0.0, 1.0 };
    GLfloat light_diffuse[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat light_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat light_position[] = { 1.0, 1.0, 1.0, 0.0 };

    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);
    glLightfv(GL_LIGHT0, GL_DIFFUSE, light_diffuse);
    glLightfv(GL_LIGHT0, GL_SPECULAR, light_specular);
    glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);

    glEnable(GL_DEPTH_TEST);

}

void display(void)
{
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    glPushMatrix();
    glRotatef(20.0, 1.0, 0.0, 0.0);

    glMaterialfv(GL_FRONT, GL_AMBIENT, mat1_amb);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat1_dif1);
    glMaterialfv(GL_FRONT, GL_SPECULAR, mat1_spec);
    glMaterialf(GL_FRONT, GL_SHININESS, mat1_shininess);

    glPushMatrix();
    glTranslatef(0.0, -1.1, 0.5);
    glRotatef(90.0, 1.0, 0.0, 0.0);
    glutSolidTorus(0.275, 1.1, 15, 15);
    glPopMatrix();

    glMaterialfv(GL_FRONT, GL_AMBIENT, mat1_amb);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat1_dif2);
    glMaterialfv(GL_FRONT, GL_SPECULAR, mat1_spec);
    glMaterialf(GL_FRONT, GL_SHININESS, mat1_shininess);

    glPushMatrix();
    glTranslatef(0.0, -0.6, 0.5);
    glRotatef(90.0, 1.0, 0.0, 0.0);
    glutSolidTorus(0.275, 0.95, 15, 15);
    glPopMatrix();

    glMaterialfv(GL_FRONT, GL_AMBIENT, mat1_amb);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat1_dif3);
    glMaterialfv(GL_FRONT, GL_SPECULAR, mat1_spec);
    glMaterialf(GL_FRONT, GL_SHININESS, mat1_shininess);

    glPushMatrix();
    glTranslatef(0.0, -0.1, 0.5);
    glRotatef(90.0, 1.0, 0.0, 0.0);
    glutSolidTorus(0.275, 0.8, 15, 15);
    glPopMatrix();

    glMaterialfv(GL_FRONT, GL_AMBIENT, mat1_amb);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat1_dif4);
    glMaterialfv(GL_FRONT, GL_SPECULAR, mat1_spec);
    glMaterialf(GL_FRONT, GL_SHININESS, mat1_shininess);

    glPushMatrix();
    glTranslatef(0.0, 0.4, 0.5);
    glRotatef(90.0, 1.0, 0.0, 0.0);
    glutSolidTorus(0.275, 0.65, 15, 15);
    glPopMatrix();

    glMaterialfv(GL_FRONT, GL_AMBIENT, mat1_amb);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat1_dif5);
    glMaterialfv(GL_FRONT, GL_SPECULAR, mat1_spec);
    glMaterialf(GL_FRONT, GL_SHININESS, mat1_shininess);

    glPushMatrix();
    glTranslatef(0.0, 0.9, 0.5);
    glRotatef(90.0, 1.0, 0.0, 0.0);
    glutSolidTorus(0.275, 0.5, 15, 15);
    glPopMatrix();

    glMaterialfv(GL_FRONT, GL_AMBIENT, mat2_amb);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat2_dif);
    glMaterialfv(GL_FRONT, GL_SPECULAR, mat2_spec);
    glMaterialf(GL_FRONT, GL_SHININESS, mat2_shininess);

    glPushMatrix();
    glTranslatef(0.0, -2.0, 0.5);
    glRotatef(270.0, 1.0, 0.0, 0.0);
    glutSolidCone(1.0, 4.0, 15, 15);
    glPopMatrix();

    glMaterialfv(GL_FRONT, GL_AMBIENT, mat3_amb);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat3_dif);
    glMaterialfv(GL_FRONT, GL_SPECULAR, mat3_spec);
    glMaterialf(GL_FRONT, GL_SHININESS, mat3_shininess);

    glPushMatrix();
    glTranslatef(0.0, 1.5, 0.5);
    glutSolidSphere(0.5, 15, 15);
    glPopMatrix();

    glFlush();
}

void reshape(int w, int h)
{
    glViewport(0, 0, (GLsizei)w, (GLsizei)h);

    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();

    gluPerspective(
        45.0,
        (GLfloat)w / h,
        1, 100.0);
    glMatrixMode(GL_MODELVIEW);

    glLoadIdentity();
    gluLookAt(
        0.0f, 0.0f, 7.0f,
        0.0f, 0.0f, 0.0f,
        0.0f, 1.0f, 0.0f);
}

int main(int argc, char** argv)
{
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB
        | GLUT_DEPTH);
    glutInitWindowSize(500, 510);
    glutCreateWindow(argv[0]);
    init();
    glutReshapeFunc(reshape);
    glutDisplayFunc(display);
    glutMainLoop();
    return 0;
}
