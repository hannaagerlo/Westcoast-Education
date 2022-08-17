
import CoursesItem from "./CoursesItem";

function CoursesList(){
    <section>
    <table>
        <thead>
            <tr>
                <th>Kurstitel</th>
                <th>Kursnummer</th>
                <th>Ämne</th>
                <th>längd</th>
            </tr>
        </thead>
        <tbody><CoursesItem/></tbody>
        <tbody><CoursesItem/></tbody>
     </table>
     </section>


}
export default CoursesList;