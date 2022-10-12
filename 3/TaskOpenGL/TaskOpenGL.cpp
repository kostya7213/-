
#include <SOIL.h>
#include <stdlib.h>
#include <glut.h>
#include <math.h>

GLfloat pos0[] = { 0.0, 0.0, 1.0, 0.0 };
GLfloat pos1[] = { -100.0, 0.0, 0.0, 1.0};
GLfloat direction[] = { 100.0, 0.0, 0.0};
GLfloat diffuseColor1[] = { 1,0,1.0,1.0,0.0 };
GLfloat ambientColor0[] = { 1,0,1.0,1.0,0.0 };
GLfloat diffuseColor0[] = { 1,0,1.0,1.0,0.0 };
float ambient[] = {0.0,1.0,1.0,1.0 };
float WinWid = 800;
float WinHei = 600;
int Winw=800;
int Winh = 600;

float rot = 0.0;
float angle = 0.0;

void DrawCube()
{
	
		// передний
	glColor3f(1, 0, 0);
		glBegin(GL_QUADS);
		glVertex3f(-20.0f, 0.0f, 0.0f);
		glVertex3f(-20.0f, 50.0f, 0.0f);
		glVertex3f(30.0f, 50.0f, 0.0f);
		glVertex3f(30.0f, 0.0f, 0.0f);
		glEnd();

		// задний
		glBegin(GL_QUADS);
		glVertex3f(-20.0f, 0.0f, -50.0f);
		glVertex3f(-20.0f, 50.0f, -50.0f);
		glVertex3f(30.0f, 50.0f, -50.0f);
		glVertex3f(30.0f, 0.0f, -50.0f);
		glEnd();

		// левый 
		glBegin(GL_QUADS);
		glVertex3f(-20.0f, 0.0f, -50.0f);
		glVertex3f(-20.0f, 50.0f, -50.0f);
		glVertex3f(-20.0f, 0.5f, 0.0f);
		glVertex3f(-20.0f, 0.0f, 0.0f);
		glEnd();

		// правый
		glBegin(GL_QUADS);
		glVertex3f(30.0f, 0.0f, -50.0f);
		glVertex3f(30.0f, 30.0f, -30.0f);
		glVertex3f(30.0f, 30.0f, 0.0f);
		glVertex3f(30.0f, 0.0f, 0.0f);
		glEnd();

		// Верхний полигон
		glBegin(GL_QUADS);
		glVertex3f(-20.0f, 50.0f, 0.0f);
		glVertex3f(-20.0f, 50.0f, -50.0f);
		glVertex3f(30.0f, 50.0f, -50.0f);
		glVertex3f(30.0f, 50.0f, 0.0f);
		glEnd();

		// Нижний полигон
		glBegin(GL_QUADS);
		glVertex3f(-20.0f, 0.0f, 0.0f);
		glVertex3f(-20.0f, 0.0f, -20.0f);
		glVertex3f(30.0f, 0.0f, -50.0f);
		glVertex3f(30.0f, 0.0f, 0.0f);
		glEnd();
}

void Draw()
{
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glEnable(GL_LIGHT1);
	glEnable(GL_DEPTH_TEST);
	glClear(GL_COLOR_BUFFER_BIT|GL_DEPTH_BUFFER_BIT);

	glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuseColor0);
	glLightfv(GL_LIGHT0, GL_AMBIENT, ambientColor0);
	glLightfv(GL_LIGHT0, GL_POSITION, pos0);
	glLightfv(GL_LIGHT1, GL_DIFFUSE, diffuseColor1);
	glLightfv(GL_LIGHT1, GL_POSITION, pos1);
	glLightfv(GL_LIGHT1, GL_SPOT_DIRECTION, direction);
	glLightf(GL_LIGHT1, GL_SPOT_CUTOFF, 15.0);
	glLightf(GL_LIGHT1, GL_SPOT_EXPONENT, 100.0);
	

	glLoadIdentity();
	gluLookAt(-7.0, -10.0, 2.0, // из
		-5.0, -10.0, -10.0, // на
		0.0, 1.0, 0.0);

	glTranslatef(0.0, 0.0, -200.0);
	glColor3f(1.0, 0.0, 0.0);
	glutSolidSphere(15.0, 20.0, 20);
	glColor3f(0.0, 1.0, 0.0);
	glPushMatrix();
		glRotatef(rot, 0.0, 1.0, 0.0);
		glTranslatef(60.0, 0.0, 0.0);
		glutSolidSphere(5, 20, 20);
	glPopMatrix();
	
	DrawCube();
	rot += 5.0;
	glDisable(GL_DEPTH_TEST);
	//glDisable(GL_LIGHT0);
	glDisable(GL_LIGHT1);
	glDisable(GL_LIGHTING);

	glutSwapBuffers();
}
void Timer(int value)
{
	glutPostRedisplay();
	glutTimerFunc(50, Timer, 0);
}

void Initialize()
{
	if (WinHei == 0)
		WinHei = 1;
	float ratio = WinWid * 1.0 / WinHei;
	glClearColor(0.0, 0.0, 0.0, 1.0); glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(50.0, ratio, 1, 400.0f);
	glMatrixMode(GL_MODELVIEW);
}


int main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glEnable(GL_TEXTURE_2D);

	glutInitWindowSize(WinWid, WinHei);
	glutInitWindowPosition(100, 200);
	glutCreateWindow("Task3");



	glutDisplayFunc(Draw);
	glutTimerFunc(50, Timer, 0);
	Initialize();

	glutMainLoop();

	glDisable(GL_TEXTURE_2D);
	return 0;

}























/*


// инициализация переменных цвета в 1.0
// треугольник - белый
float red = 1.0f, blue = 1.0f, green = 1.0f;

// угол поворота камеры
float angle = 0.0;
// координаты вектора направления движения камеры
float lx = 0.0f, lz = -1.0f;
// XZ позиция камеры
float x = 0.0f, z = 5.0f;
void changeSize(int w, int h) {
	// предотвращение деления на ноль
	if (h == 0)
		h = 1;
	float ratio = w * 1.0 / h;
	// используем матрицу проекции
	glMatrixMode(GL_PROJECTION);
	// установить корректную перспективу
	gluPerspective(45.0f, ratio, 0.1f, 100.0f);


	// обнуляем матрицу
	glLoadIdentity();
	// установить параметры вьюпорта
	glViewport(0, 0, w, h);
	// вернуться к матрице проекции
	glMatrixMode(GL_MODELVIEW);
}
void drawSnowMan() {

	glColor3f(1.0f, 1.0f, 1.0f);

	// тело снеговика
	glTranslatef(0.0f, 0.75f, 0.0f);
	glutSolidSphere(0.75f, 20, 20);

	// голова снеговика
	glTranslatef(0.0f, 1.0f, 0.0f);
	glutSolidSphere(0.25f, 20, 20);
	// глаза снеговика
	glPushMatrix();
	glColor3f(0.0f, 0.0f, 0.0f);
	glTranslatef(0.05f, 0.10f, 0.18f);
	glutSolidSphere(0.05f, 10, 10);
	glTranslatef(-0.1f, 0.0f, 0.0f);
	glutSolidSphere(0.05f, 10, 10);
	glPopMatrix();
	// нос снеговика
	glColor3f(1.0f, 0.5f, 0.5f);
	glRotatef(0.0f, 1.0f, 0.0f, 0.0f);
	glutSolidCone(0.08f, 0.5f, 10, 2);
}
void processSpecialKeys(int key, int xx, int yy) {
	float fraction = 0.1f;
	switch (key) {
	case GLUT_KEY_LEFT:
		angle -= 0.01f;
		lx = sin(angle);
		lz = -cos(angle);
		break;
	case GLUT_KEY_RIGHT:
		angle += 0.01f;
		lx = sin(angle);
		lz = -cos(angle);
		break;
	case GLUT_KEY_UP:
		x += lx * fraction;
		z += lz * fraction;
		break;
	case GLUT_KEY_DOWN:
		x -= lx * fraction;
		z -= lz * fraction;
		break;
	}
}
void renderScene(void) {
	// Очистка буфера цвета и глубины.
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	// обнулить трансформацию
	glLoadIdentity();
	// установить камеру
	gluLookAt(x, 1.0f, z,
		x + lx, 1.0f, z + lz,
		0.0f, 1.0f, 0.0f);
	// нарисуем "землю"
	glColor3f(0.0f, 1.0f, 0.0f);
	glBegin(GL_QUADS); // полигон с коондинатами
	glVertex3f(-50.0f, 0.0f, -50);
	glVertex3f(-50.0f, 0.0f, 50);
	glVertex3f(50.0f, 0.0f, 50.0f);
	glVertex3f(50.0f, 0.0f, -50.0f);
	glEnd();
			glPushMatrix();
			glTranslatef(1.0, 0,1.0);
			drawSnowMan();
			glPopMatrix();
		
	glutSwapBuffers();
}

void processNormalKeys(unsigned char key, int x, int y) {

	if (key == 27)
		exit(0);
}
float ambient[] = { 1.0,1.0,1.0,1.0 };

int main(int argc, char** argv) {
	// Инициализация и создание окна
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGBA);
	glutInitWindowPosition(100, 100);
	glutInitWindowSize(400, 400);
	glutCreateWindow("Task3");



	glEnable(GL_LIGHTING);
	glLightModelfv(GL_LIGHT_MODEL_AMBIENT,ambient);	




	// Регистрация
	glutDisplayFunc(renderScene);
	glutReshapeFunc(changeSize);
	glutIdleFunc(renderScene);
	glutKeyboardFunc(processNormalKeys);
	glutSpecialFunc(processSpecialKeys);

	// Инициализация OpenGL функции теста
	glEnable(GL_DEPTH_TEST);

	// Основной цикл GLUT
	glutMainLoop();

	return 1;
}
*/