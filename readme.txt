Project ko build kèm Home khi lên scorm, mỗi file Lesson là 1 Chương tách riêng, kèm Sub Lesson


Tạo bài mới:
Lesson T1 (Chương): 
- Set link button với các scene Lesson tương ứng
- Set tên và thumb cho các Button lesson

Lesson T2 (Cấp 2):
- Lesson 1,2,3,...: đổi text main name, hình thumb
- Panel - LessonT2 List: xếp cấu trúc các LessonT2 trong này, link với Data Lesson T2 Prefab tương ứng

Data Lesson T2:
- Resources/LessonT2/Folder các chương tương ứng/Prefab LT2_Part_1, 2, 3,.....
- Cấu trúc gồm nhiều Lesson T3 trong đó: LT3_Part_1, 2, 3,....., có script LessonT3.cs
- Trong mỗi LT3_Part_ lại gồm các model 3D, có script ModelPrefabRef
- Nhớ scale model cho phù hợp với các model khác
- Nhập thông tin trong LessonT3 phù hợp với các dạng: Interactive, Image, Video. Nếu là dạng Interactive thì cần link thêm với Animation Controller


Animation Controller điều khiển model3D:
- Resources/Prefab/2DComponent/AnimationController/
- Group ngoài để Full Rect scale theo canvas, có script AnimationController riêng của nội dung học, kế thừa từ AnimationController gốc
- Các tham số link với các bộ phận của model 3D theo references



