import React from 'react';
import { Header, Menu } from '../parts/PageParts';

export class RulesPage extends React.Component {
    render() {
        return (
            <div>
                <Header>
                    <Menu />
                </Header>

                <div className="document">
                    <h1>Competition Rules</h1>

                    {/* GENERAL INFORMATION */ }
                    <h2>Article I. General Information</h2>
                    <p>The following Rules &amp; Guidelines have been developed by the NJBA Time Trial Committee for the benefit of our time trial series race promoters and our race participants. The purpose of the Guidelines is to remind both promoters and racers of the important components involved in hosting an NJBA TT Cup Event and of the overall Series. The Time Trial Cup Committee reserves the right to modify or change these Rules, Regulations and Guidelines at any time, in the sole discretion of the Time Trial Cup Committee.</p>

                    <p>Conditions for Participation - By participating in the Time Trial Cup, promoters and racers are hereby agreeing to follow all rules and guidelines, and to pay heightened attention to all suggested items. Any promoter who fails to adhere to the mandatory items shall not be considered for future participation in the TT Cup Series, and may have his race removed from the Series with no advance notice required. Any rider who fails to adhere to these rules may be disqualified from the Series, and prohibited from racing future events in the Series in the current year, or in years subsequent. </p>

                    {/* RIDER QUALIFICATIONS */ }
                    <h2>Article II. Rider Qualifications to Participate in the TT Cup</h2>
                    <p>All Junior Riders are eligible to participate in the TT Cup.</p>

                    <p>Non-Junior riders must meet the following qualifications to participate in the TT Cup.</p>
                    <ol>
                        <li>Be a member of a Team (or Club) in good standing with the NJBA for the current year.</li>
                        <li>Register for each race with the correct team name associated on their BikeReg account.</li>
                    </ol>

                    <p>To be considered in good standing, the Team must be registered with the NJBA and have paid the yearly dues (via BikeReg).</p>
                    <p>Should the Team not be in good standing, a grace period consisting of the first three races is granted in which a rider may be awarded points should the Team register by the event date of the fourth race.</p>
                    
                    {/* RACE CATEGORIES */ }
                    <h2>Article III. Racing Categories</h2>

                    <p>Other than at the NJ ITT State Championship, promoters must ensure that they have, at minimum, the below categories in all their events. This is a condition to being a promoting event in our TT Cup Series. The above categories must be provided, with no exceptions or changes so participating athletes can properly score points for the TT Cup categories in which they are competing. Promoters may add additional categories if they desire as long as all the categories noted above are present.</p>

                    <h3>Section I. TT Bike Categories</h3>
                    <p>The following categories will be scored as an individual cup.</p>
                    <ul>
                        <li>Junior Men 10-12</li>
                        <li>Junior Men 13-14</li>
                        <li>Junior Men 15-16</li>
                        <li>Junior Men 17-18</li>
                        <li>Junior Women 10-14</li>
                        <li>Junior Women 15-18</li>
                        <li>Senior Men (Cat 1/2/3/4/5)</li>
                        <li>Senior Women (Cat 1/2/3/4/5)</li>
                        <li>Men Cat 4/5</li>
                        <li>Women Cat 4/5</li>
                        <li>Masters 45+</li>
                        <li>Masters 50+</li>
                        <li>Masters 55+</li>
                        <li>Masters 60+</li>
                        <li>Masters 65+</li>
                    </ul>

                    <h3>Section II. Non-TT Bike Categories</h3>
                    <p>In addition to the above TT Bike Categories scored for the TT Cup, additional Non-TT Bike Categories are included. For both Men and Women, one or more Non-TT Bike Categories are provided. The "Open" Category consisting of Category 1/2/3/4/5 Riders and "Cat 5" Category consisting of Category 5 riders.</p>
                    <h4>Bike Qualifications to race in a Non-TT Bike Category</h4>
                    <p>Officials reserve the right to make judgements on the eligibiltiy of new or otherwise unknown equipement during each event. Should there be a question, the Rider will be asked to remove the equipment and/or replace with legal equipment. Failing to do so will result in disqualification from participation in the TT Cup.</p>
                    <ul>
                        <li>No TT Bikes Allowed</li>
                        <li>No forward extending bars or aerodynamic extensions including but not limited to ski bars, U-bars, tri-bars, bullhorns, or oversized computer mounts.</li>
                        <li>No disc wheels, spoke covers or other forms of solid construction aero wheels such as trispoke or spinergy wheels</li>
                        <li>Bicycles must conform to USAC Rules for Mass Start racing</li>
                        <li>Skinsuits <i>are</i> allowed</li>
                        <li>Aerodynamic and TT helmets <i>are</i> allowed</li>
                    </ul>

                    {/* SCORING */ }
                    <h2>Article IV. TT Cup Scoring</h2>

                    <h3>Section I. Scoring Rules</h3>
                    <p>All races will be weighted equally. </p>
                    <p>In determining the final computation of the TT Cup Series total points for each rider, the final computation as performed by the TT Cup Committee shall require that each riders' lowest 2 scores be dropped as noted below. This dropped scores shall be "dropped" at season end in the final computation by the TT Cup Committee. </p>
                    <p>The term Lowest Score shall be deemed to include any race where a rider in fact completes the race and receives a placing or score or Cup points, as well as any race in which a rider started but "Did Not Finish", or any race in which a rider "Did not Start", or any race in which a rider failed to register and compete. Hence, a rider need not race a race to drop that particular race. Thus, a DNS, DNF or Failed to Register/Compete shall be considered "scores" for the sake of the mandatory dropping of scores as noted below.</p>
                    <p>In the event that the cup has seven (8) or fewer races, the TT Cup Committee reserves the right to decide whether or not no drops will be given.</p>

                    <h4>Tie Breakers</h4>
                    <p>In the event of a tie score/time as determined by the USAC officials, the TT Cup points awarded for such placings representing the tied riders shall be aggregated and shared evenly amongst the tied riders. To score, a rider must not only register and start a race, but must also finish and be given a scored time. Any rider who "does not start" (DNS) or "does not finish" (DNF) shall not be awarded any points irrespective if the promoter includes the riders or bib number on the scoring sheets. A rider must finish with a scored time to be awarded TT Cup points.</p>

                    <p>At season-end, in the event there are riders in the same Cup classification with the same number of total points, then ties are broken by totaling the number of 1st place finishes, then 2nd place finishes, then 3rd place finishes, etc. until a clear winner is established. This will apply to all categories in the NJ Time Trial Cup.</p>

                    <h3>Section II. Scoring Schedule</h3>
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Rider Placing</th>
                                <th>Points Awarded</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>20</td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td>19</td>
                            </tr>
                            <tr>
                                <td>3</td>
                                <td>18</td>
                            </tr>
                            <tr>
                                <td>4</td>
                                <td>17</td>
                            </tr>
                            <tr>
                                <td>5</td>
                                <td>16</td>
                            </tr>
                            <tr>
                                <td>6</td>
                                <td>15</td>
                            </tr>
                            <tr>
                                <td>7</td>
                                <td>14</td>
                            </tr>
                            <tr>
                                <td>8</td>
                                <td>13</td>
                            </tr>
                            <tr>
                                <td>9</td>
                                <td>12</td>
                            </tr>
                            <tr>
                                <td>10</td>
                                <td>11</td>
                            </tr>
                            <tr>
                                <td>11</td>
                                <td>10</td>
                            </tr>
                            <tr>
                                <td>12</td>
                                <td>9</td>
                            </tr>
                            <tr>
                                <td>13</td>
                                <td>8</td>
                            </tr>
                            <tr>
                                <td>14</td>
                                <td>7</td>
                            </tr>
                            <tr>
                                <td>15</td>
                                <td>6</td>
                            </tr>
                            <tr>
                                <td>16</td>
                                <td>5</td>
                            </tr>
                            <tr>
                                <td>17</td>
                                <td>4</td>
                            </tr>
                            <tr>
                                <td>18</td>
                                <td>3</td>
                            </tr>
                            <tr>
                                <td>19</td>
                                <td>2</td>
                            </tr>
                            <tr>
                                <td>20</td>
                                <td>1</td>
                            </tr>
                        </tbody>
                    </table>

                    <h3>Section III. Event Registration</h3>
                    <p>At each race that is part of the TT Cup, all riders competing for the TT Cup Series must register in their respective TT Cup category at each race comprising the TT Cup with the possible exception of the New Jersey Individual Time Trial Championships, as noted below.</p>

                    <p>For example, a rider competing in the Masters 35+ TT Cup grouping must register in the M35 field at each individual race in order to receive M35 TT Cup points. The sole exception is as follows: At NJITT, New Jersey Individual Time Trial Championships, due to the age brackets, riders may earn TT Cup points though racing in a NJITT age group one five year increment greater than their TT Cup group. For example, at NJITT there are groupings in 5-year increments, while the TT Cup may have 10-year increments. Thus, for example, a rider who is 42 years old, who has been competing in the M35 groupings at all other events, may elect to race the 40+ NJITT category. Despite racing the 40+ category, all results from the 35 and 40 plus category, as it relates to TT Cup points, shall be aggregated. It should also be noted that the riders in the NJITT 35+ and NJITT 40+ fields shall considered as one field as it relates to determining NJC Cup Series scoring. For example, a rider in the 40+ may win that category, win the NJITT Champion's Jersey for the 40+ field, but if 2 riders from the NJITT M35 category have faster times, then in aggregating the 35+ and 40+ NJITT fields, that 40+ rider shall replace "third place" points. Despite having won his 40+ category, in aggregating the two categories, he had only the third fastest time.</p>

                    <p>As such, the following categories will be aggregated as noted below:</p>
                    <ol>
                        <li>NJITT 35+ and NJITT 40+, aggregated to calculate TT Cup category 35+</li>
                        <li>NJITT 45+ and NJITT 50+, aggregated to calculate TT Cup category 45+</li>
                        <li>NJITT 55+ and NJITT 60+, aggregated to calculate TT Cup category 55+</li>
                        <li>NJITT 65+ and NJITT 70+, aggregated to calculate TT Cup category 65+</li>
                    </ol>

                    <h4>Attention NJC TT Cup Series Category 4/5 Riders</h4>
                    <p>Due to USAC's regulations regarding State Championships, there is no Category 4/5 State Championship field at the NJITT. To earn 4/5 TT Cup Series Points, 4/5 Category riders wanting to earn Cup points need to enter the Open/Senior Men or Women's Category.</p>

                    <p>It is important to note that if a Cat 4/5 rider enters any category other than Senior Men/Women at the NJITT, their score will not count as it relates to the 4/5 TT Cup Series, though they may earn TT Cup Series points in that other age grouping. It is the riders' responsibility to ensure they have registered themselves properly in the correct field.</p>

                    <h3>Section III. Exceptions</h3>
                    <h4>Junior Classes Excluded from Flanders and High Point</h4>
                    <p>The promoters and townships involved have requested that Junior classes be excluded from the High Point and Flanders Time Trials for safety reasons. Thus, the Junior riders will have two less events comprising their TT Cup calendar. </p>

                    {/* PROMOTOR REQUIREMENTS */}
                    <h2>Article V. Promotor Requirements</h2>
                    <p>All Promoters hereby agree to promote and put forth their time trials in line with the Rules and Regulations contained here; In the event a Promoter or Race fails to adhere to these Rules and Regulations, the Time Trial Cup Committee reserves its right to immediately withdraw any such even from the TT Cup Series, at any time.</p>

                    <p>TT Cup Race Application - All promoters, unless exempted by the TT Cup Committee in writing, must submit a TT Cup Race Application so that the TT Cup Committee may make such a determination as to whether the race shall be included in the TT Cup Series. The Application shall disclose many relevant items, including how the promoters previous TT promoting experience, how the promoter intends to properly score and computer placings (must be done electronically; no hand computation of final times or results), as well as a description of the course and other material components of the race. The TT Cup Committee shall thereafter advise the promoter in writing, or email, as to its determination as to whether the race shall be part of the TT Cup Series.</p>

                    <p>Pre-registration – Promoters may permit same-day registration yet can only do so if they can ensure that same-day registrants are sorted and given start times that are within, or adjacent to the riders correct racing category and in line with the Starting Order requirements noted below herein. Promoters may "build in" a couple of "blank" slots between each category which will serve to create time cushions between differing racing  categories, but then can also be used to slot in same-day registrants. (See more below). If a promoter cannot ensure that same-day registrants can be started within, or adjacent to their category competitors, then the promoter cannot offer same-day registrant. We strongly recommend limited registration to preregistration in advance of the race, avoiding any same-day registrations.</p>

                    <p>Unless an exception is permitted by the TT Cup Committee, online Registration must remain open at least until Wednesday preceding the event, until at least 9 pm at night. A promoter may leave registration open longer or later in the week as long as they can properly handle their back office and other administrative responsibilities so as to comply with our other requirements herein.</p>

                    <p>New Events – For any promoter wishing consideration in the TT Cup Series they shall exhibit proficiency in running an event one year before Cup status can be granted. Refunds or Rain dates - In the event a race is cancelled in whole, or in part, for no fault of the riders, then the promoter must reimburse all riders their entire entry fee, or provide notice in advance of rain date for the event. If no rain date is provided in advance, and the event is not rescheduled, then the promoters must refund entry fee monies to riders within a reasonable number of days subsequent to the cancelled event.</p>

                    <p>USAC Regulations – Promoters may not impose any bike or equipment standards (such as prohibiting disc wheels or aero helmets), without getting advance permission from the TT Cup Committee. Promoters must advise and receive permission from the TT Cup Committee if their race is not USAC conforming. For example, if a promoter is going to prohibit the use of aero bar extensions, this must be a) disclosed to the TT Cup Committee in advance and receive TT Cup approval, and b) be clearly presented on preregistration and other marketing materials so all riders are aware of the condition. Otherwise, all USAC regulations pertaining to bicycle equipment, clothing and other regulations shall be controlling.</p>

                    <p>Start Order &amp; Numbering – Will be at the Promoter's discretion</p>

                    <p>Time Gaps - Promoters should have time gaps no less than 30 seconds. Suggestion: promoters will help themselves if, when creating start lists, they put a few (2 recommended) 30 second "blank slots" in between categories. This will help create a cushion and separate categories and avoid, for example, a junior being too overrun by a faster rider behind. As well, those gaps will ensure that if you've missed anyone, or have to make a race-day addition or exception, you have some slots you can fill last minute. We strongly recommend assigning these "blank" slots actual race bib numbers so there is no confusion or mistaken start times on the line. These blank slots should get start numbers, and the officials will "start" these vacant slots (basically, just letting the time go by with no rider up). Ensure your manual start sheets that you provide to the officials have these blanks listed clearly:</p>
                    <ol>
                        <li># 229 Tom Jones 10:02:30</li>
                        <li># 230 BLANK 10:03:00</li>
                        <li># 231 BLANK 10:03:30</li>
                    </ol>

                    <p>Time keeping / Scoring - This item is one of the most critical items. In all situations, Promoters must use some form of Electronic timing or scoring, as best possible to ensure accurate and timely results. This would include use of a spreadsheet program into which rider start and finish times shall be inputted, and the program shall generate computed times and scoring. While manual-scoring sheets may, and should, be maintained by race officials or timing persons as backup, as a failsafe in the event of a technical failure, the promoter must utilize an electronic, spreadsheet, database-type system. ** The NJBA TT Cup Committee can refer promoters to parties who can handle the electronic scoring for minimal monies. The TT Cup Committee reserves the right to require proof of suchtiming or scoring before including the event in the Series.</p>

                    <p>DNS and DNF – TT Cup points are only awarded to riders who start a race and finish a race. If a rider starts but "does not finish", or registers but "does not start", then that rider shall not be awarded TT Cup Series points. As such, all race promoters must clearly notate any registered rider who either a) does not start, b) does not finish or c) does not get a scored time for any other reason. We ask that any riders who do not start or do not finish have their scores on the final scoring sheet properly notated with DNS or DNF notations.</p>

                    <p>Results, Protests - Promoters should strive to quickly present correct and timely results in initial draft form, then, after presenting "FINAL" results. Subsequent to posting "Final" results, there shall be a 15minute protest period during which riders or officials may modify and correct results. After the 15minute protest period has elapse, if no further disputes or issues have been presented, then the results become final and nonappealable. Promoters shall ensure they announce loudly that results are posted, and notate the beginning of the 15-minute appeal period.</p>

                    <p>No Promoter shall, subsequent to the protest period, modify any results whatsoever without advising the NJ TT Cup of such a proposed change and receiving the TT Cup's permission to modify such results. The rationale for this is that each race has a significant and material impact on the TT Cup Series points that a rider attains. A rider in the Cup chase has an expectation of knowing that, once the 15 minutes have elapsed, they can leave the race without worry that the results, and Cup points earned, will not change without their being present to defend their points and position.</p>

                    <p>Residual Issues, Disputes, and Appeals - Promoters shall record and memorialize any issues with scoring or disputes, and shall forward to the NJ TT Cup an electronic copy of the final results and placings. The Final results must be sent to <strong>John Sedlak</strong> within 48 hours of the end of the event.</p>

                    <p>Submission of Results - Promoters must provide an electronically formatted list that includes both ALL registered riders and final results to the TT Cup Committee no later than 2 days after the event. Please make note of this change from years past in which only final results were required to be submitted. The results must be in electronic format, such as Microsoft Excel, with all the following fields in the results file:</p>
                    <ol>
                        <li>Rider First Name</li>
                        <li>Rider Last Name</li>
                        <li>USAC License number</li>
                        <li>Team</li>
                        <li>Category (if junior or masters, must break it out by age)</li>
                        <li>Place/result within Category</li>
                        <li>Time</li>
                    </ol>

                    <p>Start Line - The promotes must provide a rider holder to hold riders at the start time; this must be provided, other than in the Team time trial events or Team time trial categories.</p>

                    <p>Marshalling - the Promoter shall provide sufficient and ample marshals to ensure a safe and proper event; Marshalls should be provided with orange vests and cones, and instructed as to how to properly flag/point riders thru turns, and where to stand to marshal properly; No material intersection or turn can be without a marshal protecting the rider's safety. Promoters will ensure they spend time with the marshals explaining proper technique for waiving riders thru turns or around cones.</p>

                    <p>Turn around Signage, Cone, and Finish Line - Promoters shall post at minimum of 1 (one) sign/advisory stating the distance to the turn-around cone (if any), approximately 500meters from the turn around, stating the distance to the turn around. A Turn around cone shall be designated by a single orange "large" or other highly visible cone, with a "turn around marshal" adjacent to the cone advising riders to turn. </p>

                    <p>Finish Line - Promoters shall post a sign/advisory no less than 500 meters from the finish line, stating the distance to the finish. The finish shall be clearly marked by a line, or tape, across the road, as well as an orange cone positioned directly on the finishing line, on the side of the road.</p>

                    <h2>Article VI. Mandatory use of the TT Cup Logo</h2>
                    <p>The promoter shall include the NJBA TT Cup Logo on the promoters BikeReg or other registration website; on the Promoters' Club's website if such a website is maintained where the race is presented and discuss; on any and all other materials where the race is presented, marketed, promoted or discussed. It shall be a small logo that shall designatethe race as part of the Series. The logo shall be provided to the promoters in the coming months. It will not be obtrusive.</p>

                    <h2>Article VII.USA Cycling and the U.S. Anti- Doping Agency</h2>
                    <p>In order to maintain a level, drug free racing environment, we work closely with the U.S. Anti- Doping Agency (USADA) to implement a robust athlete testing program that includes all levels of competition, as well as out of competition testing. Therefore, it is important for you to remember that as a member of USA Cycling, you could be subject to testing by USADA at any time during our Cup series, with, or without notice.</p>
                </div>
            </div>
        )
    }
}